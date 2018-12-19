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

    adminSectionList("Edit Section List");


}

function adminSectionList(heading) {
    $(".toSectionList").on("click", function () {

        $("h1").text(heading);

        
        $.get("/Admin/SectionList/", function (data) {
            $(".contentSection").html(data);
            adminSectionEdit(heading);
            adminCategoryList(heading);
            adminReloadToIndex();

        });
    });
}

function adminSectionEdit(prevHeading) {
    $(".sectionEdit a").on("click", function () {
        clickedOnTextToH1(this);
        var id = $(this).attr("id");
        $.get("/Admin/SectionEdit/" + id, function (data) {
            $(".contentSection").html(data);
            adminSectionList(prevHeading);
            adminReloadToIndex();

        });
    });
}

function adminCategoryList(prevHeading) {

    $(".toCategoryList a").on("click", function () {
        clickedOnTextToH1(this);
        var id = $(this).attr("id");
        $.get("/Admin/CategoryList/" + id, function (data) {
            $(".contentSection").html(data);

            adminCategoryEdit();
            adminSpeciesList();
            adminSectionList(prevHeading);
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
        clickedOnTextToH1(this);
        var id = $(this).attr("id");
        $.get("/Admin/CategoryEdit/" + id, function (data) {
            $(".contentSection").html(data);
            adminReloadToIndex();
        });
    });
}

function adminSpeciesList() {
    $(".toSpeciesList a").on("click", function () {
        clickedOnTextToH1(this);
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
        clickedOnTextToH1(this);
        var id = $(this).attr("id");
        $.get("/Admin/SpeciesEdit/" + id, function (data) {
            $(".contentSection").html(data);
            adminReloadToIndex();
        });
    });
}

function adminSightingList() {
    $(".toSightingList a").on("click", function () {
        clickedOnTextToH1(this);
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
        clickedOnTextToH1(this);
        var id = $(this).attr("id");
        $.get("/Admin/SightingEdit/" + id, function (data) {
            $(".contentSection").html(data);
            adminReloadToIndex();
        });
    });
}

function adminFigureList() {
    $(".toFigureList a").on("click", function () {
        clickedOnTextToH1(this);
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
        clickedOnTextToH1(this);
        var id = $(this).attr("id");
        $.get("/Admin/FigureEdit/" + id, function (data) {
            $(".contentSection").html(data);
            adminReloadToIndex();
        });
    });
}

function clickedOnTextToH1(selector) {
    var heading = $(selector).text();
    $("h1").text(heading);
}
