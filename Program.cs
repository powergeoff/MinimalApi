var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/checkDir", () => "Root Directory: " + Directory.GetCurrentDirectory());

app.MapGet("/deleteTemp", () => {
    string path = "healthcheck";
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
app.MapGet("/createTemp", () => {
    string pathString = "healthcheck"; 
    try
    {
        //string pathString = System.IO.Path.Combine("healthcheck"); 
        System.IO.Directory.CreateDirectory(pathString);
        string fileName = "healthy";
        pathString = System.IO.Path.Combine(pathString, fileName);

        if (!System.IO.File.Exists(pathString))
        {
            using (System.IO.FileStream fs = System.IO.File.Create(pathString))
            {
                for (byte i = 0; i < 100; i++)
                {
                    fs.WriteByte(i);
                }
            }
        }
        else
        {
            return "File already exists.";
        }
    }
    catch(Exception e)
    {
        return e.Message;
    }
    return "Temp File Created at:" + pathString;
});


app.MapGet("/checkTemp", () => {
    string path = "healthcheck";
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
