using System;
using Serilog;
using Serilog.Core;

namespace Utilities
{
    public static class CustomLogger
    {
        public static Logger log = new LoggerConfiguration().WriteTo.File("log.txt", 
                                                                            outputTemplate:"[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                                                                .CreateLogger();



    }
}
