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

$(document).ready(function () {
    //could make this into a function that gets run on page load and then again at end of each ajax operation
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

function adminSectionList() {
    $(".toSectionList").on("click", function () {

        $.get("/Admin/SectionList/", function (data) {
            $(".contentSection").html(data);
            adminSectionEdit();
            adminCategoryList();
            adminReloadToIndex();

        });
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
        });
    });
}

function adminSubmitSection() {
    $(".submitSection").on("click", function () {
        var data = {
            SectionId: $("#sectionId").val(),
            SectionName: $("#sectionName").val(),
            SectionIntro: $("#sectionIntro").val()
        };

        $.post("/Admin/SectionSave/", data, function () {
            $.get("/Admin/SectionList/", function (data) {
                $(".contentSection").html(data);
                adminSectionEdit();
                adminCategoryList();
                adminReloadToIndex();
            });
        });
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

