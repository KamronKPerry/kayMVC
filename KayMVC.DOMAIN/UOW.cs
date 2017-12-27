using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KayMVC.DATA;
using KayMVC.DOMAIN.Repositories;

namespace KayMVC.DOMAIN
{
    public interface IUOW : IDisposable
    {
        //This is for DI/IOC (MVC4) - before this implementation thi
        //interface only had the requirement of the Save().

        //Ensure that any class that implements IUnitOfWork has properties for each
        //of our repositories

        AboutsRepository AboutsRepository { get; }
        GraphicSampleRepository GraphicSampleRepository { get; }
        PictureRepository PictureRepository { get; }
        ResumeUploadRepository ResumeUploadRepository { get; }
        WritingSamplesRepository WritingSamplesRepository { get; }
        //AuthorRepository AuthorRepository { get; }
        //GenreRepository GenreRepository { get; }
        //PublisherRepository PublisherRepository { get; }
        //TitleRepository TitleRepository { get; }
        //WishlistRepository WishlistRepository { get; }
        void Save();
    }
    //the public class UOW IMPLEMENTS IUnitOfWork
    public class UOW : IUOW
    {
        /*
        ACESS MODIFIERS
        Public - Can be accessed from anywhere
        Private - Limited to inside the Class
        Protected - Limited to within the class AND child classes
        Internal - Limited to within the Assembly (project)
        Protected Internal - Limited to the Assembly AND in the class AND Inherited members
        
        */
        //fields
        internal kaylahSiteEntities ksx = new kaylahSiteEntities();
        private AboutsRepository _aboutsRepository;
        private GraphicSampleRepository _graphicSampleRepository;
        private PictureRepository _pictureRepository;
        private ResumeUploadRepository _resumeUploadRepository;
        private WritingSamplesRepository _writingSamplesRepository;

        //properties
        public AboutsRepository AboutsRepository
        {
            get
            {
                if (this._aboutsRepository == null)
                {
                    this._aboutsRepository = new AboutsRepository(ksx);
                }
                return _aboutsRepository;
            }
        }
        public GraphicSampleRepository GraphicSampleRepository
        {
            get
            {
                if (this._graphicSampleRepository == null)
                {
                    this._graphicSampleRepository = new GraphicSampleRepository(ksx);
                }
                return _graphicSampleRepository;
            }
        }
        public PictureRepository PictureRepository
        {
            get
            {
                if(this._pictureRepository == null)
                {
                    this._pictureRepository = new PictureRepository(ksx);
                }
                return _pictureRepository;
            }
        }
        public ResumeUploadRepository ResumeUploadRepository
        {
            get
            {
                if(this._resumeUploadRepository == null)
                {
                    this._resumeUploadRepository = new ResumeUploadRepository(ksx);
                }
                return _resumeUploadRepository;
            }
        }
        public WritingSamplesRepository WritingSamplesRepository
        {
            get
            {
                if(this._writingSamplesRepository == null)
                {
                    this._writingSamplesRepository = new WritingSamplesRepository(ksx);
                }
                return _writingSamplesRepository;
            }
        }
        //ctors

        //events

        //methods
        public void Save()
        {
            ksx.SaveChanges();
        }
        //this is a private local variable, that is why it is located here
        //it is a private becasue it is ONLY used here, and omits the _
        //because it is seen as a local variable, not used in refactoring.
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)//true
                {
                    ksx.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //ToString()

    }
}