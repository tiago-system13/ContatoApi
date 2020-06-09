using System;

namespace bdiEntidades.Constatntes
{
    public static class EnviromentConstant
    {
        public static readonly string DATABASE_CONNECTION_STRING = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
    }
}
