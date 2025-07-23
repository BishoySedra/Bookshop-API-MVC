namespace Models.Models
{
    public class Category
    {
        #region Properties
        public int Id { get; set; }
        public string catName { get; set; }

        public int catOrder { get; set; }

        public DateTime createdDate { get; set; }

        public bool markedAsDeleted { get; set; }
        #endregion
    }
}
