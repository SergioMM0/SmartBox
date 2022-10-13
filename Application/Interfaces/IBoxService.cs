using Application.Validators;

namespace Domain.Interfaces;

public interface IBoxService
{
    public List<Box> GetAllBoxes();

    public Box CreateNewBox(PostBoxDTO dto);
}