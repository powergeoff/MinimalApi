var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapGet("/checkDir", () => "Root Directory: " + Directory.GetCurrentDirectory());

app.MapGet("/deleteTemp", () => {
    string path = Directory.GetCurrentDirectory() + "\\temp";
    try
    {
        var dir = new DirectoryInfo(@path);
        dir.Delete(true);
    }
    catch(Exception e)
    {
        return e.Message;
    }
    return "Temp File Deleted";
});

app.MapGet("/checkTemp", () => {
    string path = Directory.GetCurrentDirectory() + "\\temp";
    try
    {
        var dir = new DirectoryInfo(@path);
        if(Directory.Exists(path))
        {
            return $"Directory {path} exists!";
        } else 
        {
            return $"Directory {path} does not exist";
        }
    }
    catch(Exception e)
    {
        return e.Message;
    }
});

app.Run();
