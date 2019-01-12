function hideSomething(whatToHide) {
    $('.hidden').removeClass('hidden');
    $(whatToHide).addClass('hidden');
}

function showSomething(whatToShow) {
    $('.photoSection p').hide();
    $(whatToShow).show();
}

function toggleSomething(whatToToggle) {

    $(whatToToggle).toggle();

}

//AJAX functions

$(document).ready(function () {
    homePageReady();
    adminIndexReady();
});

function homePageReady() {
    $('.photoSection p, .speciesList div').hide();
    $(".headerLinks a").on("click", function () {
        //clickedOnTextToH1(this);
        var id = $(this).attr("id");
        if (id === "homeHeader") {
            $.get("/Home/HomePage/", function (data) {
                $(".contentSection").html(data);

                $('.photoSection p, .speciesList div').hide();
            });
        }
        else if (id !== "homeHeader") {
            $.get("/Home/Section/" + id, function (data) {
                $(".contentSection").html(data);

                $('.photoSection p, .speciesList div').hide();
            });
        }
    });
}

function adminIndexReady() {

    adminSectionList();


}

function adminReloadToIndex() {
    $(".toAdminIndex").on("click", function () {
        location.reload();
        adminIndexReady();
    });
}
//adminList and adminEdit page functions
function adminSectionList() {
    $(".toSectionList").on("click", function () {

        getSectionList();
    });
}

function getSectionList() {
    $.get("/Admin/SectionList/", function (data) {
        $(".contentSection").html(data);
        adminSectionEdit();
        adminCategoryList();
        adminDeleteSection();
        adminAddNewSection();
        adminReloadToIndex();
    });
}

function adminSectionEdit() {
    $(".sectionEdit a").on("click", function () {

        var id = $(this).attr("id");
        $.get("/Admin/SectionEdit/" + id, function (data) {
            $(".contentSection").html(data);
            adminSectionList();
            adminReloadToIndex();
            adminSubmitSection();

        });
    });
}

function adminCategoryList() {

    $(".toCategoryList a").on("click", function () {

        var sectionId = $(this).attr("id");
        getCategoryList(sectionId);
    });
}

function adminBackToCatList(sectionId) {
    $(".backToCatList").on("click", function () {
        getCategoryList(sectionId);
    });
}

function getCategoryList(sectionId) {
    $.get("/Admin/CategoryList/" + sectionId, function (data) {
        $(".contentSection").html(data);
        adminCategoryEdit(sectionId);
        adminSpeciesList(sectionId);
        adminDeleteCategory(sectionId);
        adminAddNewCategory(sectionId);
        adminSectionList();
        adminReloadToIndex();
    });
}


function adminCategoryEdit(sectionId) {
    $(".toCategoryEdit a").on("click", function () {

        var id = $(this).attr("id");
        $.get("/Admin/CategoryEdit/" + id, function (data) {
            $(".contentSection").html(data);
            adminReloadToIndex();
            adminSubmitCategory(sectionId);
            adminBackToCatList(sectionId);
        });
    });
}

function adminSpeciesList(sectionId) {
    $(".toSpeciesList a").on("click", function () {

        var categoryId = $(this).attr("id");
        getSpeciesList(categoryId, sectionId);
    });
}

function getSpeciesList(categoryId, sectionId) {
    $.get("/Admin/SpeciesList/" + categoryId, function (data) {
        $(".contentSection").html(data);
        adminSpeciesEdit(categoryId, sectionId);
        adminSightingList(categoryId, sectionId);
        adminDeleteSpecies(categoryId, sectionId);
        adminAddNewSpecies(categoryId, sectionId);
        adminBackToCatList(sectionId);
        adminReloadToIndex();
    });
}

function adminSpeciesEdit(categoryId, sectionId) {
    $(".toSpeciesEdit a").on("click", function () {

        //var id = $(this).attr("id");
        $.get("/Admin/SpeciesEdit/" + categoryId, function (data) {
            $(".contentSection").html(data);
            adminReloadToIndex();
            adminSubmitSpecies(categoryId, sectionId);
            adminBackToSpecList(categoryId, sectionId);
        });
    });
}

function adminBackToSpecList(categoryId, sectionId) {
    $(".backToSpecList").on("click", function () {
        getSpeciesList(categoryId, sectionId);
    });
}

function adminSightingList(categoryId, sectionId) {
    $(".toSightingList a").on("click", function () {

        var speciesId = $(this).attr("id");
        getSightingList(speciesId, categoryId, sectionId);
    });
}

function getSightingList(speciesId, categoryId, sectionId) {
    $.get("/Admin/SightingList/" + speciesId, function (data) {
        $(".contentSection").html(data);
        adminSightingEdit(speciesId, categoryId, sectionId);
        adminFigureList(speciesId, categoryId, sectionId);
        adminDeleteSighting(speciesId, categoryId, sectionId);
        adminAddNewSighting(speciesId, categoryId, sectionId);
        adminBackToSpecList(categoryId, sectionId);
        adminReloadToIndex();
    });
}

function adminSightingEdit(speciesId, categoryId, sectionId) {
    $(".toSightingEdit a").on("click", function () {

        var sightingId = $(this).attr("id");
        $.get("/Admin/SightingEdit/" + sightingId, function (data) {
            $(".contentSection").html(data);
            adminReloadToIndex();
            adminSubmitSighting(speciesId, categoryId, sectionId);
            adminBackToSighList(speciesId, categoryId, sectionId);
        });
    });
}

function adminBackToSighList(speciesId, categoryId, sectionId) {
    $(".backToSighList").on("click", function () {
        getSightingList(speciesId, categoryId, sectionId);
    });
}

function adminFigureList(speciesId, categoryId, sectionId) {
    $(".toFigureList a").on("click", function () {

        var sightingId = $(this).attr("id");
        getFigureList(sightingId, speciesId, categoryId, sectionId);
    });
}

function getFigureList(sightingId, speciesId, categoryId, sectionId) {
    $.get("/Admin/FigureList/" + sightingId, function (data) {
        $(".contentSection").html(data);
        adminFigureEdit(sightingId, speciesId, categoryId, sectionId);
        adminDeleteFigure(sightingId, speciesId, categoryId, sectionId);
        adminAddNewFigure(sightingId, speciesId, categoryId, sectionId);
        adminBackToSighList(speciesId, categoryId, sectionId);
        adminReloadToIndex();
    });
}

function adminFigureEdit(sightingId, speciesId, categoryId, sectionId) {
    $(".toFigureEdit a").on("click", function () {

        var figureId = $(this).attr("id");
        $.get("/Admin/FigureEdit/" + figureId, function (data) {
            $(".contentSection").html(data);
            adminReloadToIndex();
            adminSubmitFigure(sightingId, speciesId, categoryId, sectionId);
            adminBackToFigList(sightingId, speciesId, categoryId, sectionId);
        });
    });
}

function adminBackToFigList(sightingId, speciesId, categoryId, sectionId) {
    $(".backToFigList").on("click", function () {
        getFigureList(sightingId, speciesId, categoryId, sectionId);
    });
}

//submitFunctions for editPages
function adminSubmitSection() {
    $(".submitSection").on("click", function () {
        var data = {
            SectionId: $("#sectionId").val(),
            SectionName: $("#sectionName").val(),
            SectionIntro: $("#sectionIntro").val()
        };
        if (data.SectionId === "") {
            $.post("/Admin/SectionAdd/", data, function () {
                getSectionList();
            });
        } else {
            $.post("/Admin/SectionSave/", data, function () {
                getSectionList();
            });
        }
    });
}

function adminSubmitCategory(sectionId) {
    $(".submitCategory").on("click", function () {
        var data = {
            CategoryId: $("#categoryId").val(),
            SectionId: $("#sectionId").val(),
            CategoryName: $("#categoryName").val()
        };
        if (data.CategoryId === "") {
            $.post("/Admin/CategoryAdd/", data, function () {
                getCategoryList(sectionId);
            });
        } else {
            $.post("/Admin/CategorySave/", data, function () {
                getCategoryList(sectionId);
            });

        }

    });
}

function adminSubmitSpecies(categoryId, sectionId) {
    {
        $(".submitSpecies").on("click", function () {
            var data = {
                SpeciesId: $("#speciesId").val(),
                CategoryId: $("#categoryId").val(),
                CommonName: $("#commonName").val(),
                LatinName: $("#latinName").val()
            };
            if (data.SpeciesId === "") {
                $.post("/Admin/SpeciesAdd/", data, function () {
                    getSpeciesList(categoryId, sectionId);
                });
            } else {
                $.post("/Admin/SpeciesSave/", data, function () {
                    getSpeciesList(categoryId, sectionId);
                });
            }

        });
    }
}

function adminSubmitSighting(speciesId, categoryId, sectionId) {
    {
        $(".submitSighting").on("click", function () {
            var data = {
                SightingId: $("#sightingId").val(),
                SpeciesId: $("#speciesId").val(),
                WhenSeen: $("#whenSeen").val(),
                WhereSeen: $("#whereSeen").val(),
                HowMany: $("#howMany").val(),
                Comment: $("#comment").val()
            };

            if (data.SightingId === "") {
                $.post("/Admin/SightingAdd/", data, function () {
                    getSightingList(speciesId, categoryId, sectionId);
                });
            } else {
                $.post("/Admin/SightingSave/", data, function () {
                    getSightingList(speciesId, categoryId, sectionId);
                });
            }
            
        });
    }
}

function adminSubmitFigure(sightingId, speciesId, categoryId, sectionId) {
    {
        $(".submitFigure").on("click", function () {
            var data = {
                FigureId: $("#figureId").val(),
                SightingId: $("#sightingId").val(),
                Source: $("#source").val(),
                Alternative: $("#alternative").val(),
                Caption: $("#caption").val()

            };

            if (data.FigureId === "") {
                $.post("/Admin/FigureAdd/", data, function () {
                    getFigureList(sightingId, speciesId, categoryId, sectionId);
                });
            } else {
                $.post("/Admin/FigureSave/", data, function () {
                    getFigureList(sightingId, speciesId, categoryId, sectionId);
                });
            }
        });
    }
}

//deleteFns for listPages
function adminDeleteSection() {
    $(".deleteSection a").on("click", function () {

        var id = $(this).attr("id");
        $.post("/Admin/SectionDelete/" + id, function () {
            getSectionList();

        });
    });
}

function adminDeleteCategory(sectionId) {
    $(".deleteCategory a").on("click", function () {
        var id = $(this).attr("id");
        $.post("/Admin/CategoryDelete/" + id, function () {
            getCategoryList(sectionId);
        });
    });
}

function adminDeleteSpecies(categoryId, sectionId) {
    $(".deleteSpecies a").on("click", function () {
        var id = $(this).attr("id");
        $.post("/Admin/SpeciesDelete/" + id, function () {
            getSpeciesList(categoryId, sectionId);
        });
    });
}

function adminDeleteSighting(speciesId, categoryId, sectionId) {
    $(".deleteSighting a").on("click", function () {
        var id = $(this).attr("id");
        $.post("/Admin/SightingDelete/" + id, function () {
            getSightingList(speciesId, categoryId, sectionId);
        });
    });
}

function adminDeleteFigure(sightingId, speciesId, categoryId, sectionId) {
    $(".deleteFigure a").on("click", function () {
        var id = $(this).attr("id");
        $.post("/Admin/FigureDelete/" + id, function () {
            getFigureList(sightingId, speciesId, categoryId, sectionId);
        });
    });
}
//Add fns
function adminAddNewSection() {
    $(".toAddNewSection").on("click", function () {
        $.get("/Admin/NewSection/", function (data) {
            $(".contentSection").html(data);
            adminSectionList();
            adminReloadToIndex();
            adminSubmitSection();
        });
    });
}

function adminAddNewCategory(sectionId) {
    $(".toAddNewCategory").on("click", function () {
        $.get("/Admin/NewCategory/" + sectionId, function (data) {
            $(".contentSection").html(data);

            adminReloadToIndex();
            adminSubmitCategory(sectionId);
        });
    });

}

function adminAddNewSpecies(categoryId, sectionId) {
    $(".toAddNewSpecies").on("click", function () {
        $.get("/Admin/NewSpecies/" + categoryId, function (data) {
            $(".contentSection").html(data);

            adminReloadToIndex();
            adminSubmitSpecies(categoryId, sectionId);
            adminBackToSpecList(categoryId, sectionId);
        });
    });
}

function adminAddNewSighting(speciesId, categoryId, sectionId) {
    $(".toAddNewSighting").on("click", function () {
        $.get("/Admin/NewSighting/" + speciesId, function (data) {
            $(".contentSection").html(data);

            adminReloadToIndex();
            adminSubmitSighting(speciesId, categoryId, sectionId);
            adminBackToSighList(speciesId, categoryId, sectionId);
        });
    });
}

function adminAddNewFigure(sightingId, speciesId, categoryId, sectionId) {
    $(".toAddNewFigure").on("click", function () {
        $.get("/Admin/NewFigure/" + sightingId, function (data) {
            $(".contentSection").html(data);

            adminReloadToIndex();
            adminSubmitFigure(sightingId, speciesId, categoryId, sectionId);
            adminBackToFigList(sightingId, speciesId, categoryId, sectionId);
        });
    });
}