namespace CHUSHKA.WEB.ViewModels
{
    using CHUSHKA.Models;
    using System;

    public class OrderViewModel
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public ChushkaUser Client { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}