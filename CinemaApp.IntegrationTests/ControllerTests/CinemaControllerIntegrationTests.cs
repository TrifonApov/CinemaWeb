namespace CinemaApp.IntegrationTests.ControllerTests
{
    using CinemaApp.Web;

    [TestFixture]
    public class CinemaControllerIntegrationTests
    {
        private readonly CinemaAppWebApplicationFactory<Program> cinemaAppFactory;
        private readonly HttpClient cinemaAppClient;

        public CinemaControllerIntegrationTests()
        {
            this.cinemaAppFactory = new CinemaAppWebApplicationFactory<Program>();
            this.cinemaAppClient = cinemaAppFactory.CreateClient();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.cinemaAppClient.Dispose();
            this.cinemaAppFactory.Dispose();
        }

        [Test]
        public async Task Index_AnonymousUser_ReturnsCorrectHTTPCodeAndResultType()
        {
            // Arrange
            string url = "/Cinema/Index";

            // Act
            HttpResponseMessage response = await cinemaAppClient.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.That(response.Content.Headers.ContentType!.MediaType, Is.EqualTo("text/html"));
        }
    }
}
