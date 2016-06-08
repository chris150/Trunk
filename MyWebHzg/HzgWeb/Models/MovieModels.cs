using Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Mvc;
using MyWebHzg.Entities;

namespace MyWebHzg.Frontend.HzgWeb.Models
{

    public enum Mode : byte
    {
        New,
        Edit
    }


    public class NewEditMovieModel
    {
        private Movie movie;
        private List<SelectListItem> genres;
        private List<SelectListItem> mediumtypes;
        
        public NewEditMovieModel()
        {
            this.movie = new Movie();
            genres = new List<SelectListItem>();
            mediumtypes = new List<SelectListItem>();
        }

        public Mode Mode { get; set; }

        public string Title
        {
            get
            {
                ResourceManager rm = new ResourceManager(typeof(BasicRes));
                return rm.GetString(this.Mode.ToString());
            }

        }

        public Movie Movie { 
            get { return movie; }
            set { this.movie = value; }
        }

        public List<SelectListItem> Genres
        {
            get { return this.genres; }
        }

        public List<SelectListItem> MediumTypes
        {
            get { return this.mediumtypes; }
        }        
    }


    public class DirectoryTreeNode
    {
        private List<DirectoryTreeNode> childNodes;
        private bool isFile = false;
        private bool isReady = true;

        public DirectoryTreeNode()
        {
            childNodes = new List<DirectoryTreeNode>();
        }

        public string Id { get; set; }
        public string Text { get; set; }
        public string ParentId { get; set; }

        public bool HasChilds
        {
            get { return this.childNodes.Count() > 0; }
        }

        public bool IsFile
        {
            get { return this.isFile; }
            set { this.isFile = value; }
        }

        public bool IsReady
        {
            get { return isReady; }
            set { isReady = value; }
        }

        public string Path { get; set; }
        public List<DirectoryTreeNode> ChildNodes { get { return this.childNodes; } }

    }
}