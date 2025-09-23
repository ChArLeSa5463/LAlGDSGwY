// 代码生成时间: 2025-09-23 22:00:16
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MauiApp
{
    // 数据库迁移工具
    public class DatabaseMigrationTool
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseMigrationTool(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // 执行数据库迁移
        public async Task MigrateDatabaseAsync<TContext>(bool force) where TContext : DbContext
        {
            using (TContext context = _serviceProvider.GetRequiredService<TContext>())
            {
                await context.Database.MigrateAsync();
            }
        }

        // 回滚数据库迁移
        public async Task RollbackMigrationAsync<TContext>() where TContext : DbContext
        {
            using (TContext context = _serviceProvider.GetRequiredService<TContext>())
            {
                // 获取所有迁移
                var migrations = await context.Database.GetMigrationsAsync();
                if (!migrations.Any())
                {
                    throw new InvalidOperationException("No migrations found to rollback.");
                }

                // 获取最后一个迁移
                var lastMigration = migrations.Last();

                // 回滚最后一个迁移
                await context.Database.MigrateAsync(lastMigration);
            }
        }
    }
}
