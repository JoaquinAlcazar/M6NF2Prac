using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using program;

namespace M6UF2Prac;

public class SessionFactoryStoreCloud
    
{
    private static string ConnectionString = "Server=postgresql-joaquinalcazaritb.alwaysdata.net;Port=5432;Database=joaquinalcazaritb_store;User Id=joaquinalcazaritb;Password=indescifrable1;";
    private static ISessionFactory? session;

    public static ISessionFactory CreateSession()
    {
        if (session != null)
            return session;

        IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
        var configMap =
            Fluently.Configure().Database(configDB).Mappings(
                c => c.FluentMappings.AddFromAssemblyOf<Program>());

        session = configMap.BuildSessionFactory();

        return session;
    }

    public static ISession Open()
    {
        return CreateSession().OpenSession();
    }
}

