using Application.DTOs;

namespace Domain.Interfaces;

public interface IBoxService
{
    public List<Box> GetAllBoxes();

    public Box CreateNewBox(PostBoxDTO dto);

    public void RebuildDb();
}