namespace deneme
{
    public partial class MainPage : ContentPage
    {
        private readonly DataService _dataService;

        public MainPage()
        {
        }

        public MainPage(DataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Veritabanından ürünleri getir
            var products = await _dataService.GetProductsAsync();

            // Gelen ürünleri ekrana yazdır
            foreach (var product in products)
            {
                Console.WriteLine(product); // Konsolda göster
            }
        }
    }
}
