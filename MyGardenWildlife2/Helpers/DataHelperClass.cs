using MyGardenWildlife2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGardenWildlife2.Helpers
{
    public class DataHelperClass


    {
        public static List<CategoryModel> GetInvertsData()
        {
            var returnObject = new List<CategoryModel>()
            {
                GetDragonflyData(),
                GetBugData(),
                GetBeetlesData(),
                GetButterflyData(),
                GetBeesData(),
                GetFliesData(),
                GetSpidersData(),
                GetSnailsData(),




            };

            return returnObject;
        }


        public static CategoryModel GetButterflyData()
        {
            var returnObject = new CategoryModel
            {
                CategoryName = "Butterflies and Moths",
                Id = 1,
                SpeciesList = new List<SpeciesModel>
                {
                    new SpeciesModel
                        {
                            CommonName = "Meadow Brown Butterfly",
                            LatinName = "Maniola jurtina",
                            SightingList = new List<SightingModel>
                            {
                                new SightingModel
                                {
                                    Where = "Meadow",
                                    When = new DateTime(2018,6,25),
                                }
                            }
                        },
                    new SpeciesModel
                        {
                            CommonName= "Painted Lady Butterfly",
                            LatinName = "Vanessa cardui",
                            SightingList = new List<SightingModel>
                            {
                                new SightingModel
                                {
                                    Where = "Meadow, on corn chamomile",
                                    When = null,//"24th June 2015",
                                    HowMany = 1,
                                    Figure = new List<FigureModel>() {
                                        new FigureModel()
                                    {
                                        Caption = "Painted lady, 24/06/2015",

                                            Source = "painted_lady.jpg",
                                            Alternative = "Painted Lady"

                                    }
                                    }
                                 }
                            }
                        },
                    new SpeciesModel
                        {
                            CommonName = "Ringlet Butterfly",
                            LatinName = "Aphantopus hyperantus",
                            SightingList = new List<SightingModel>
                            {
                                new SightingModel
                                {
                                    Where = "Meadow",
                                    When = null,//"27th June 2017",
                                    HowMany = 1,
                                    Comment = "Aberration lanceolata.",
                                     Figure = new List<FigureModel>() {new FigureModel()
                                    {
                                        Caption = "Aberrant Ringlet Butterfly, 27/06/2017",
                                        
                                            Source = "Ringlet.jpg",
                                            Alternative = "Ringlet, Aberrant"

                                        
                                    } }
                                }
                            }
                        },
                    new SpeciesModel
                         {
                            CommonName = "Small Tortoiseshell Butterfly",
                            LatinName = "Aglais urticae",
                            SightingList = new List<SightingModel>
                            {
                                new SightingModel
                                {
                                    Where ="South-Facing border",
                                    When = null,//"24th June 2018",
                                    HowMany = 2
                                }
                            }
                        },

                }
            };

            return returnObject;

        }

        public static CategoryModel GetBugData()
        {
            var returnObject = new CategoryModel
            {
                CategoryName = "Bugs, crickets, grasshoppers and aphids",
                Id = 2,
                SpeciesList = new List<SpeciesModel>()
                {
                    new SpeciesModel
                    {
                        CommonName = "Dock Bug",
                        LatinName = "Coreus marginatus",

                    }
                }
            };
            return returnObject;

        }

        public static CategoryModel GetDragonflyData()
        {
            var returnObject = new CategoryModel
            {
                CategoryName = "Dragonflies, damselflies and mayflies",
                Id = 3,
                SpeciesList = new List<SpeciesModel>()
                {
                    new SpeciesModel
                    {
                        CommonName = "Banded Demoiselle damselfly",
                        LatinName = "Calopteryx splendens",
                    }
                }
            };

            return returnObject;

        }

        public static CategoryModel GetBeetlesData()
        {
            var returnObject = new CategoryModel
            {
                CategoryName = "Beetles",
                Id = 4,
                SpeciesList = new List<SpeciesModel>()
                {
                    new SpeciesModel
                    {
                        CommonName = "Cockchafer",
                        LatinName = "Melolontha melolontha",
                        SightingList = new List<SightingModel>
                        {
                            new SightingModel
                            {
                                Where = "North Border, on rose leaf",
                                When  =null,//"30th May 2017",
                                Figure = new List<FigureModel>() { new FigureModel()
                                {
                                    Caption ="Cockchafer, 30/5/2017",
                                    
                                        Source = "Chafer.JPG",
                                         Alternative = "Cockchafer",
                                    
                                }
                                }
                            }
                        }


                    }
                }
            };

            return returnObject;
        }



        public static CategoryModel GetBeesData()
        {
            var returnObject = new CategoryModel
            {
                CategoryName = "Bees, wasps and ants",
                Id = 5,
                SpeciesList = new List<SpeciesModel>()
                {
                    new SpeciesModel
                    {
                        CommonName = "Red-tailed Bumblebee",
                        LatinName = "Bombus lapidarius",
                        SightingList = new List<SightingModel>
                        {
                            new SightingModel
                            {
                                Where = "Near pond, visiting a poppy",
                                HowMany = 1,
                                When = null,//"26th June 2018"
                            }
                        }

                    }
                }
            };

            return returnObject;
        }

        public static CategoryModel GetFliesData()
        {
            var returnObject = new CategoryModel
            {
                CategoryName = "Flies",
                Id = 6,
                SpeciesList = new List<SpeciesModel>()
                {
                    new SpeciesModel
                    {
                        CommonName = "",
                        LatinName = "",
                    }
                }


            };

            return returnObject;
        }

        public static CategoryModel GetSpidersData()
        {
            var returnObject = new CategoryModel
            {
                CategoryName = "Spiders",
                Id = 7,
                SpeciesList = new List<SpeciesModel>()
            };

            return returnObject;
        }

        public static CategoryModel GetSnailsData()
        {
            var returnObject = new CategoryModel
            {
                CategoryName = "Snails, slugs and worms",
                Id = 8,
                SpeciesList = new List<SpeciesModel>()
            };

            return returnObject;
        }

        public static CategoryModel GetSouthFacingData()
        {


            var returnObject = new CategoryModel
            {
                CategoryName = "South Facing Border",
                Id = 9,
                SpeciesList = new List<SpeciesModel>()
                {
                    new SpeciesModel
                    {
                        CommonName = "Foxglove",
                        LatinName = "Digitalis purpurea",

                    },
                    new SpeciesModel
                    {
                        CommonName = "Sage",
                        LatinName = "Salvia officinalis"

                    },

                },

            };

            return returnObject;

        }





    }
}