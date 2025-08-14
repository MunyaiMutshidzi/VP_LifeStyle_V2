namespace VP_LifeStyle_V2.Models.ProductMenuViewModel
{
    public class PageInfoViewModel
    {
        public int TotalItems {  get; set; }
        public int ItemsPerPage {  get; set; }
        public int CurrentPage {  get; set; }
        public int TotalPages =>//Important- creates a list of pages needed based on the 
                               //Number of Items each page has/carries.
            (int)Math.Ceiling((decimal)TotalItems/ItemsPerPage);
    }
}
