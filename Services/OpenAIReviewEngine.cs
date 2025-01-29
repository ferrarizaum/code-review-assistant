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
            _client = new(model: "gpt-4o-mini", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
        }

        public async Task<ReviewResultDTO> AnalyzeCodeAsync(string code)
        {
            ChatCompletion completion = await _client.CompleteChatAsync($"Review the following code as if you were a nice senior developer, being really brief:\n{code}");

            return new ReviewResultDTO
            {
                Feedback = completion.Content.First().Text
            };
        }
    }
}
