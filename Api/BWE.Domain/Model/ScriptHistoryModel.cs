using BWE.Domain.DBModel;

namespace BWE.Domain.Model
{
    public class ScriptHistoryModel
    {
        public int Id { get; set; }
        public int ScriptId { get; set; }
        public int Status { get; set; }
        public string Output { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public static implicit operator ScriptHistoryModel(ScriptHistory v)
        {
            throw new NotImplementedException();
        }
    }
}
