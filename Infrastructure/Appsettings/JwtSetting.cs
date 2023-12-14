﻿namespace Infrastructure.Appsettings
{
    public class JwtSetting
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ValidTime { get; set; }
        public string SecretKey { get; set; }
    }
}
