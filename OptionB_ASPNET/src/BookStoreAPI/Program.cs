using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHttpsRedirection(options =>
        {
            options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            options.HttpsPort = 5001;
        });
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        // Configure Kestrel to use a self-signed certificate for development
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.ConfigureHttpsDefaults(httpsOptions =>
            {
                var certPath =  @"C:\Certs\bookStoreCertificate.pfx";
                var certPassword = "se173437";
                if (File.Exists(certPath))
                {
                    try
                    {
                        httpsOptions.ServerCertificate = new X509Certificate2(certPath, certPassword,
                            X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
                        Console.WriteLine($"Successfully loaded certificate from {certPath}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while loading the certificate: {ex.Message}");
                        Console.WriteLine($"StackTrace: {ex.StackTrace}");  // In thêm stack trace
                        httpsOptions.ServerCertificate = GenerateFallbackCertificate();
                    }
                }
                else
                {
                    Console.WriteLine($"Certificate file not found: {certPath}");
                    // Handle the missing file scenario (e.g., log it, use a fallback certificate, etc.)
                    // Fallback certificate logic
                    httpsOptions.ServerCertificate = GenerateFallbackCertificate();
                }
            });
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();        
        app.MapControllers();
        
        app.Run();
    }

    private static X509Certificate2 GenerateFallbackCertificate()
    {
        // Generate a self-signed certificate as a fallback
        var ecdsa = ECDsa.Create();
        var req = new CertificateRequest("cn=localhost", ecdsa, HashAlgorithmName.SHA256);
        var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1));
        return new X509Certificate2(cert.Export(X509ContentType.Pfx));
    }
}