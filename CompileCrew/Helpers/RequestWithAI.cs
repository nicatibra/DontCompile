using RestSharp;
using Method = RestSharp.Method;

namespace CompileCrew.Helpers
{
    public static class RequestWithAI
    {
        public static string Test()
        {
            string prompt = "Please detecte this prompt and tell me that is logical complaint or suggestion, or not. And answer me with just one word. True or False. Just it. {Prompt}";
            string model = "command-r-plus-08-2024";
            var response = AskCohereAsync(prompt, model);
            return response.ToString();
        }
        public async static Task<string> AskCohereAsync(string prompt, string model)
        {
            var client = new RestClient(new RestClientOptions("https://api.cohere.ai/generate")
            {
                Timeout = TimeSpan.FromHours(3)
            });

            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer RryI2ry8jq23sIkdt1NQb8ScQ7JDXVLCAZn2fqE3");

            var body = new
            {
                prompt = prompt,
                model = model,
                temperature = 0.8,
            };

            request.AddJsonBody(body);
            var response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"API response contains an error: {response.Content}");
            }
            return response.Content;
        }

        public static string Test1()
        {
            string prompt = "The employee will give a reason for taking vacation. Check and see if the reason is valid, allow him to take vacation. For example, if he gives a very important reason vacation is given and answered with yes or no. And answer me with just one word. Yes or No. Just it. {Prompt}";
            string model = "command-r-plus-08-2024";
            var response = AskCohereAsync1(prompt, model);
            return response.ToString();
        }
        public async static Task<string> AskCohereAsync1(string prompt, string model)
        {
            var client = new RestClient(new RestClientOptions("https://api.cohere.ai/generate")
            {
                Timeout = TimeSpan.FromHours(3)
            });

            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer RryI2ry8jq23sIkdt1NQb8ScQ7JDXVLCAZn2fqE3");

            var body = new
            {
                prompt = prompt,
                model = model,
                temperature = 0.8,
            };

            request.AddJsonBody(body);
            var response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"API response contains an error: {response.Content}");
            }
            return response.Content;
        }
    }
}
