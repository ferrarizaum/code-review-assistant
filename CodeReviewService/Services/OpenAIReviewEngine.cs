﻿using CodeReviewAssistant.DTO;
using OpenAI;
using OpenAI.Chat;

namespace CodeReviewAssistant.Services
{
    public interface IAIReviewEngine
    {
        Task<ReviewResultDTO> AnalyzeCodeAsync(string code);
    }

    public class OpenAIReviewEngine : IAIReviewEngine
    {
        private readonly ChatClient _client;

        public OpenAIReviewEngine()
        {
            _client = new(model: "gpt-3.5-turbo", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
        }

        public async Task<ReviewResultDTO> AnalyzeCodeAsync(string code)
        {
            //ChatCompletion completion = await _client.CompleteChatAsync($"Write a two line review about the following code:\n{code}");

            return new ReviewResultDTO
            {
                //Feedback = completion.Content.First().Text
                Feedback = "This is the result"
            };
        }
    }
}
