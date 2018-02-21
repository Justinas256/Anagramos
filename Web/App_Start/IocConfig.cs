using Anagram.Business;
using Anagram.Core;
using Anagram.SQL;
using Anagrams.EF.Core;
using Anagrams.EFCF.Core;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Web.App_Start
{
    public class IocConfig
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder = SetEFCF(builder);

            builder.RegisterType<CachedWordsService>().As<ICachedWordsService>();
            builder.RegisterType<UserLogService>().As<IUserLogService>();
            builder.RegisterType<WordsService>().As<IWordsService>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static ContainerBuilder SetEFCF(ContainerBuilder builder)
        {
            builder.RegisterType<WordsEFCFRepository>().As<IWordRepository>();
            builder.RegisterType<CachedWordsEFCFRepository>().As<ICachedWordsRepository>();
            builder.RegisterType<UserLogEFCFRepository>().As<IUserLogRepository>();

            builder.RegisterType<WordsEFCFRepository>().Named<IWordRepository>("reader");
            builder.Register(c => new OneWordFinder(c.ResolveNamed<IWordRepository>("reader").GetData())).As<IAnagramSolver>();
            return builder;
        }

        private static ContainerBuilder SetEFDF(ContainerBuilder builder)
        {
            builder.RegisterType<WordsEFRepository>().As<IWordRepository>();
            builder.RegisterType<CachedWordsEFRepository>().As<ICachedWordsRepository>();
            builder.RegisterType<UserLogEFRepository>().As<IUserLogRepository>();

            builder.RegisterType<WordsEFRepository>().Named<IWordRepository>("reader");
            builder.Register(c => new OneWordFinder(c.ResolveNamed<IWordRepository>("reader").GetData())).As<IAnagramSolver>();
            return builder;
        }

        private static ContainerBuilder SetSQL(ContainerBuilder builder)
        {
            string sqlCon = AppConfig.ConnectionString;

            builder.RegisterType<WordSQLRepository>().As<IWordRepository>().WithParameter("connectionString", sqlCon);
            builder.RegisterType<CachedWordsSQLRepository>().As<ICachedWordsRepository>().WithParameter("connectionString", sqlCon);
            builder.RegisterType<UserLogSQLRepository>().As<IUserLogRepository>().WithParameter("connectionString", sqlCon);

            builder.RegisterType<WordSQLRepository>().Named<IWordRepository>("reader").WithParameter("connectionString", sqlCon); ;
            builder.Register(c => new OneWordFinder(c.ResolveNamed<IWordRepository>("reader").GetData())).As<IAnagramSolver>();
            return builder;
        }
    }
}