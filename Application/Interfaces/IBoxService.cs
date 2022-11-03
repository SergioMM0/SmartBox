using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IBoxService
{
    public List<Box> GetAllBoxes();

    public Box CreateNewBox(PostBoxDTO dto);
    public Box DeleteBox(int id);
}