namespace HomeRest.Repositories;

public class SectionRepository : CrudRepositoryBase, ISectionRepository
{
    public SectionRepository(IWebHostEnvironment env, IConfiguration configuration) : base(env, configuration, "sections", "CREATE TABLE sections (id CHAR(36) DEFAULT 0 NOT NULL PRIMARY KEY title VARCHAR(255) NOT NULL, subtitle VARCHAR(255) NOT NULL, body TEXT NOT NULL)") {}
}