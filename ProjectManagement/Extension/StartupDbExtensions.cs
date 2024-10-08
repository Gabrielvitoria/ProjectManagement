﻿using Microsoft.EntityFrameworkCore;
using ProjectManagement.Infra;

namespace ProjectManagement.Extension
{
    public static class StartupDbExtensions
    {
        public static async void CreateDbIfNotExists(this IHost host) { 
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var contextProject = services.GetRequiredService<ProjectManagementContext>();


           await contextProject.Database.EnsureCreatedAsync();

        }

    }
}
