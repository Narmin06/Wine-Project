using App.Business.Services.ExternalServices.Interfaces;
using App.Business.Services.InternalServices.Interfaces;
using App.Core.DTOs.SlideDTOs;
using App.Core.Entities;
using App.Core.Exceptions.Commons;
using App.DAL.Repositories.Interfaces;
using AutoMapper;

namespace App.Business.Services.InternalServices.Abstractions;

public class SlideService : ISlideService
{
    private readonly ISlideRepository _slideRepository;
    private readonly IFileManagerService _fileManagerService;
    private readonly IMapper _mapper;

    public SlideService(
        ISlideRepository slideRepository,
        IFileManagerService fileManagerService,
        IMapper mapper)
    {
        _slideRepository = slideRepository;
        _fileManagerService = fileManagerService;
        _mapper = mapper;
    }

    public async Task<SlideDTO> AddAsync(CreateSlideDTO dto)
    {
        var slide = _mapper.Map<Slide>(dto);
        var addedSlide = await _slideRepository.AddAsync(slide);
        return _mapper.Map<SlideDTO>(addedSlide);
    }

    public IQueryable<SlideDTO> GetAll()
    {
        var slides = _slideRepository.GetAll(x => !x.IsDeleted);
        return slides.Select(s => _mapper.Map<SlideDTO>(s));
    }

    public IQueryable<SlideDTO> GetAllActive()
    {
        var slides = _slideRepository.GetAllActive(x => true);
        return slides.Select(s => _mapper.Map<SlideDTO>(s));
    }

    public IQueryable<SlideDTO> GetAllDeleted()
    {
        var slides = _slideRepository.GetAllDeleted(x => true);
        return slides.Select(s => _mapper.Map<SlideDTO>(s));
    }

    public SlideDTO GetById(int id)
    {
        var slide = _slideRepository.GetById(x => x.Id == id && !x.IsDeleted);
        return _mapper.Map<SlideDTO>(slide);
    }

    public async Task RemoveAsync(int id)
    {
        var slide = _slideRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _slideRepository.RemoveAsync(slide);
    }

    public async Task<SlideDTO> UpdateAsync(int id, UpdateSlideDTO dto)
    {
        var slide = _slideRepository.GetById(x => x.Id == id && !x.IsDeleted);
        
        if (dto.Image != null && !string.IsNullOrWhiteSpace(slide.ImageUrl))
        {
            await _fileManagerService.RemoveFileAsync(slide.ImageUrl);
        }

        var updatedSlide = _mapper.Map(dto, slide);
        var result = await _slideRepository.UpdateAsync(updatedSlide);
        return _mapper.Map<SlideDTO>(result);
    }

    public async Task SoftDeleteAsync(int id)
    {
        var slide = _slideRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _slideRepository.SoftDeleteAsync(slide);
    }

    public async Task RecoverAsync(int id)
    {
        var slide = _slideRepository.GetById(x => x.Id == id && x.IsDeleted);
        await _slideRepository.RecoverAsync(slide);
    }

    public async Task ActivateAsync(int id)
    {
        var slide = _slideRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _slideRepository.ActivateAsync(slide);
    }

    public async Task DeactivateAsync(int id)
    {
        var slide = _slideRepository.GetById(x => x.Id == id && !x.IsDeleted);
        await _slideRepository.DeactivateAsync(slide);
    }
}