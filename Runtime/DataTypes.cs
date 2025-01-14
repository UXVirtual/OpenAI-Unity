using System.Collections.Generic;

namespace OpenAI
{
    #region Common Data Types
    public struct Choice
    {
        public string Text { get; set; }
        public int? Index { get; set; }
        public int? Logpropbs { get; set; }
        public string FinishReason { get; set; }
    }

    public struct Usage
    {
        public string PromptTokens { get; set; }
        public string CompletionTokens { get; set; }
        public string TotalTokens { get; set; }
    }
    
    public struct OpenAIFile
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public long Bytes { get; set; }
        public long CreatedAt { get; set; }
        public string Filename { get; set; }
        public string Purpose { get; set; }
        public object StatusDetails { get; set; }
    }
    #endregion
    
    #region Models API Data Types
    public struct ListModelsResponse
    {
        public string Object { get; set; }
        public Model[] Data { get; set; }
    }

    public struct Model
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public string OwnedBy { get; set; }
        public Dictionary<string, object>[] Permission { get; set; }
    }
    #endregion

    #region Completions API Data Types
    public sealed class CreateCompletionRequest
    {
        public string Model { get; set; }
        public string Prompt { get; set; } = "<|endoftext|>";
        public string Suffix { get; set; }
        public int? MaxTokens { get; set; } = 16;
        public float? Temperature { get; set; } = 1;
        public float? TopP { get; set; } = 1;
        public int? N { get; set; } = 1;
        public bool? Stream { get; set; } = false;
        public int? Logpropbs { get; set; }
        public bool? Echo { get; set; } = false;
        public string Stop { get; set; }
        public float? PresencePenalty { get; set; } = 0;
        public float? FrequencyPenalty { get; set; } = 0;
        public int? BestOf { get; set; } = 1;
        public Dictionary<string, string> LogitBias { get; set; }
        public string User { get; set; }
    }

    public struct CreateCompletionResponse
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public long Created { get; set; }
        public string Model { get; set; }
        public Choice[] Choices { get; set; }
        public Usage Usage { get; set; }
    }
    #endregion

    #region Edits API Data Types
    public sealed class CreateEditRequest
    {
        public string Model { get; set; }
        public string Input { get; set; } = "";
        public string Instruction { get; set; }
        public float? Temperature { get; set; } = 1;
        public float? TopP { get; set; } = 1;
        public int? N { get; set; } = 1;
    }
    
    public struct CreateEditResponse
    {
        public string Object { get; set; }
        public long Created { get; set; }
        public Choice[] Choices { get; set; }
        public Usage Usage { get; set; }
    }
    #endregion

    #region Images API Data Types
    public class CreateImageRequestBase
    {
        public int? N { get; set; } = 1;
        public string Size { get; set; } = ImageSize.Size1024;
        public string ResponseFormat { get; set; } = ImageResponseFormat.Url;
        public string User { get; set; }
    }

    public sealed class CreateImageRequest: CreateImageRequestBase
    {
        public string Prompt { get; set; }
    }
    
    public sealed class CreateImageEditRequest: CreateImageRequestBase
    {
        public string Image { get; set; }
        public string Mask { get; set; }
        public string Prompt { get; set; }
    }

    public sealed class CreateImageVariationRequest: CreateImageRequestBase
    {
        public string Image { get; set; }
    }

    public struct CreateImageResponse
    {
        public long Created { get; set; }
        public ImageData[] Data { get; set; }
    }

    public struct ImageData
    {
        public string Url { get; set; }
        public string B64Json { get; set; }
    }
    #endregion

    #region Embeddins API Data Types
    public struct CreateEmbeddingsRequest
    {
        public string Model { get; set; }
        public string Input { get; set; }
        public string User { get; set; }
    }

    public struct CreateEmbeddingsResponse
    {
        public string Object { get; set; }
        public EmbeddingData[] Data;
        public string Model { get; set; }
        public Usage Usage { get; set; }
    }

    public struct EmbeddingData
    {
        public string Object  { get; set; }
        public float[] Embedding { get; set; }
        public int Index { get; set; }
    }
    #endregion

    #region Files API Data Types
    public struct ListFilesResponse
    {
        public string Object { get; set; }
        public OpenAIFile[] Data { get; set; }
    }

    public struct DeleteResponse
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public bool Deleted { get; set; }
    }

    public struct CreateFileRequest
    {
        public string File { get; set; }
        public string Purpose { get; set; }
    }
    #endregion

    #region FineTunes API Data Types
    public class CreateFineTuneRequest
    {
        public string TrainingFile { get; set; }
        public string ValidationFile { get; set; }
        public string Model { get; set; }
        public int NEpochs { get; set; } = 4;
        public int? BatchSize { get; set; } = null;
        public float? LearningRateMultiplier { get; set; } = null;
        public float PromptLossWeight { get; set; } = 0.01f;
        public bool ComputeClassificationMetrics { get; set; } = false;
        public int? ClassificationNClasses { get; set; } = null;
        public string ClassificationPositiveClass { get; set; }
        public float[] ClassificationBetas { get; set; }
        public string Suffix { get; set; }
    }

    public struct ListFineTunesResponse
    {
        public string Object { get; set; }
        public FineTune[] Data { get; set; }
    }
    
    public struct ListFineTuneEventsResponse
    {
        public string Object { get; set; }
        public FineTuneEvent[] Data { get; set; }
    }
    
    public struct FineTune
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public string Model { get; set; }
        public string FineTunedModel { get; set; }
        public string OrganizationID { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Hyperparams { get; set; }
        public OpenAIFile[] TrainingFiles { get; set; }
        public OpenAIFile[] ValidationFiles { get; set; }
        public OpenAIFile[] ResultFiles { get; set; }
        public FineTuneEvent[] Events { get; set; }
    }

    public struct FineTuneEvent
    {
        public string Object { get; set; }
        public long CreatedAt { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }
    #endregion

    #region Moderations API Data Types
    public class CreateModerationRequest
    {
        public string Input { get; set; }
        public string Model { get; set; } = ModerationModel.Latest;
    }
    
    public struct CreateModerationResponse
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public ModerationResult[] Results { get; set; }
    }

    public struct ModerationResult
    {
        public bool Flagged { get; set; }
        public Dictionary<string, bool> Categories { get; set; }
        public Dictionary<string, float> CategoryScores { get; set; }
    }
    #endregion

    #region Static String Types
    public static class ContentType
    {
        public const string MultipartFormData = "multipart/form-data";
        public const string ApplicationJson = "application/json";
    }

    public static class ImageSize
    {
        public const string Size256 = "256x256";
        public const string Size512 = "512x512";
        public const string Size1024 = "1024x1024";
    }

    public static class ImageResponseFormat
    {
        public const string Url = "url";
        public const string Base64Json = "b64_json";
    }

    public static class ModerationModel
    {
        public const string Stable = "text-moderation-stable";
        public const string Latest = "text-moderation-latest";
    }
    #endregion
}
