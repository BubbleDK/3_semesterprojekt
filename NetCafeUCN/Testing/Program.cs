using NetCafeUCN.MVC.Authentication;

string passwordHash = BCryptTool.HashPassword("Mark");
Console.WriteLine(passwordHash);
bool validate = BCryptTool.ValidatePassword("Mark", passwordHash);
Console.WriteLine(validate);