namespace PeristenciaNoSql.Models
{
    public class AlunoDbSettingsConnection
    {
        public string? ConnectionString { get; set; }

        public string? DatabaseName { get; set; }

        public string? AlunosCollectionName { get; set; }
    }
}