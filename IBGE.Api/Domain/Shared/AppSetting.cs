using System;
namespace IBGE.Api.Domain.Shared
{
	public static class AppSetting
	{
		public static string ConnectionString { get; set; } = string.Empty;
		public static string Secret { get; set; } = "WSQ9BTj8Rqy4u1Xo9++8lw==";
		public static string PrefixRoute { get; set; } = "/v{version:apiVersion}";
    }
}

