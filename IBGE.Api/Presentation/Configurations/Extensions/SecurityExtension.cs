using IBGE.Api.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IBGE.Api.Presentation.Configurations.Extensions
{
    public static class SecurityExtension
	{
        public static IServiceCollection AddSecurityCustom(this IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(AppSetting.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Free", policy => policy.RequireRole("Admin"));
                options.AddPolicy("Control", policy => policy.RequireRole("User"));
            });

            return services;
        }
	}
}

