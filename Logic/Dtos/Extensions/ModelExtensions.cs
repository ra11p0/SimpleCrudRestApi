using DatabaseAccess.DbModels;

namespace Logic.Dtos.Extensions
{
    public static class ModelExtensions
    {
        public static ModelDto ParseDto(this Model? model)
        {
            return model == null ? new ModelDto() : new ModelDto()
            {
                ModelId = model.ModelId,
                Name = model.Name
            };
        }
        public static Model ParseFromDto(this ModelDto? model)
        {
            return model == null ? new Model() : new Model()
            {
                ModelId = model.ModelId,
                Name = model.Name
            };
        }
    }
}
