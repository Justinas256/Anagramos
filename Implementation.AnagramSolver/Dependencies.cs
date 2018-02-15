using Implementation.AnagramSolver.Database;
using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver
{
    public static class Dependencies
    {
        public static IWordRepository WordRepository;
        public static IUserLogRepository UserLogRepository;
        public static ICachedWordsRepository CachedWordsRepositoy;

        public static CachedWordsService CachedWordService;
        public static UserLogService UsersLogService;

        public static IAnagramSolver Solver;

        private static string _path = AppConfig.FilePath;
        private static string _connectionStringSQL= AppConfig.ConnectionString;

        static Dependencies()
        {
            SetEF_CF();
            Solver = new OneWordFinder(WordRepository.GetData());
        }

        public static void SetServices()
        {
            CachedWordService = new CachedWordsService(CachedWordsRepositoy);
            UsersLogService = new UserLogService(UserLogRepository, new CachedWordsService(new CachedWordsEFCFRepository()));
        }

        public static void SetSQL()
        {
            WordRepository = new WordSQLRepository(_connectionStringSQL);
            UserLogRepository = new UserLogSQLRepository(_connectionStringSQL);
            CachedWordsRepositoy = new CachedWordsSQLRepository(_connectionStringSQL);
            SetServices();
        }

        public static void SetEF_DF()
        {
            WordRepository = new WordsEFRepository();
            UserLogRepository = new UserLogEFRepository();
            CachedWordsRepositoy = new CachedWordsEFRepository();
            SetServices();
        }

        public static void SetEF_CF()
        {
            WordRepository = new WordsEFCFRepository();
            UserLogRepository = new UserLogEFCFRepository();
            CachedWordsRepositoy = new CachedWordsEFCFRepository();
            SetServices();
        }

    }
}
