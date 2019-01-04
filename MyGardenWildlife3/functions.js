﻿function hideSomething(whatToHide) {
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
        clickedOnTextToH1(this);
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

//adminList and adminEdit page functions
function adminSectionList() {
    $(".toSectionList").on("click", function () {

        getSectionList();
    });
}

function getSectionList() {
    $.get("/Admin/SectionList/", function(data) {
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

        var id = $(this).attr("id");
        $.get("/Admin/CategoryList/" + id, function (data) {
            $(".contentSection").html(data);

            adminCategoryEdit();
            adminSpeciesList();
            adminSectionList();
            adminReloadToIndex();
        });
    });
}

function adminReloadToIndex() {
    $(".toAdminIndex").on("click", function () {
        location.reload();
        adminIndexReady();
    });
}

function adminCategoryEdit() {
    $(".toCategoryEdit a").on("click", function () {

        var id = $(this).attr("id");
        $.get("/Admin/CategoryEdit/" + id, function (data) {
            $(".contentSection").html(data);
            adminReloadToIndex();
            adminSubmitCategory();
        });
    });
}

function adminSpeciesList() {
    $(".toSpeciesList a").on("click", function () {

        var id = $(this).attr("id");
        $.get("/Admin/SpeciesList/" + id, function (data) {
            $(".contentSection").html(data);
            adminSpeciesEdit();
            adminSightingList();
            adminReloadToIndex();

        });
    });
}

function adminSpeciesEdit() {
    $(".toSpeciesEdit a").on("click", function () {

        var id = $(this).attr("id");
        $.get("/Admin/SpeciesEdit/" + id, function (data) {
            $(".contentSection").html(data);
            adminReloadToIndex();
            adminSubmitSpecies();
        });
    });
}

function adminSightingList() {
    $(".toSightingList a").on("click", function () {

        var id = $(this).attr("id");
        $.get("/Admin/SightingList/" + id, function (data) {
            $(".contentSection").html(data);
            adminSightingEdit();
            adminFigureList();
            adminReloadToIndex();
        });
    });
}

function adminSightingEdit() {
    $(".toSightingEdit a").on("click", function () {

        var id = $(this).attr("id");
        $.get("/Admin/SightingEdit/" + id, function (data) {
            $(".contentSection").html(data);
            adminReloadToIndex();
            adminSubmitSighting();
        });
    });
}

function adminFigureList() {
    $(".toFigureList a").on("click", function () {

        var id = $(this).attr("id");
        $.get("/Admin/FigureList/" + id, function (data) {
            $(".contentSection").html(data);
            adminFigureEdit();
            adminReloadToIndex();
        });
    });
}

function adminFigureEdit() {
    $(".toFigureEdit a").on("click", function () {

        var id = $(this).attr("id");
        $.get("/Admin/FigureEdit/" + id, function (data) {
            $(".contentSection").html(data);
            adminReloadToIndex();
            adminSubmitFigure();
        });
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

function adminSubmitCategory() {
    $(".submitCategory").on("click", function () {
        var data = {
            CategoryId: $("#categoryId").val(),
            SectionId: $("#sectionId").val(),
            CategoryName: $("#categoryName").val()
        };

        var id = data.SectionId;

        $.post("/Admin/CategorySave/", data, function () {
            $.get("/Admin/CategoryList/" + id, function (data) {
                $(".contentSection").html(data);
                adminCategoryEdit();
                adminReloadToIndex();
                adminSectionList();
                adminSpeciesList();
            });
        });
    });
}

function adminSubmitSpecies() {
    {
        $(".submitSpecies").on("click", function () {
            var data = {
                SpeciesId: $("#speciesId").val(),
                CategoryId: $("#categoryId").val(),
                CommonName: $("#commonName").val(),
                LatinName: $("#latinName").val()
            };

            var id = data.CategoryId;

            $.post("/Admin/SpeciesSave/", data, function () {
                $.get("/Admin/SpeciesList/" + id, function (data) {
                    $(".contentSection").html(data);

                    adminReloadToIndex();
                    adminSpeciesEdit();
                    adminSightingList();

                });
            });
        });
    }
}

function adminSubmitSighting() {
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

            var id = data.SpeciesId;

            $.post("/Admin/SightingSave/", data, function () {
                $.get("/Admin/SightingList/" + id, function (data) {
                    $(".contentSection").html(data);

                    adminReloadToIndex();
                    adminSightingEdit();
                    adminFigureList();

                });
            });
        });
    }
}

function adminSubmitFigure() {
    {
        $(".submitFigure").on("click", function () {
            var data = {
                FigureId: $("#figureId").val(),
                SightingId: $("#sightingId").val(),
                Source: $("#source").val(),
                Alternative: $("#alternative").val(),
                Caption: $("#caption").val()
                
            };

            var id = data.SightingId;

            $.post("/Admin/FigureSave/", data, function () {
                $.get("/Admin/FigureList/" + id, function (data) {
                    $(".contentSection").html(data);

                    adminReloadToIndex();
                    
                    adminFigureEdit();

                });
            });
        });
    }
}

//deleteFns for listPages
function adminDeleteSection() {
    $(".deleteSection a").on("click", function () {

        var id = $(this).attr("id");
        $.post("/Admin/SectionDelete/" + id, function (data) {
            getSectionList();
           
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
