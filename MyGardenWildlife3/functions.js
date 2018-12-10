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
    adminPageReady();
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
                adminPageReady();
                $('.photoSection p, .speciesList div').hide();
            });
        }
    });
}

function adminPageReady() {
   
    $("#toSectionList").on("click", function() {
        clickedOnTextToH1(this);
        $.get("/Admin/SectionList/", function(data) {
            $(".contentSection").html(data);
            adminPageReady();
        });
    });
    $(".sectionEdit a").on("click", function() {
        clickedOnTextToH1(this);
        var id = $(this).attr("id");
        $.get("/Admin/SectionEdit/" + id, function(data) {
            $(".contentSection").html(data);
            adminPageReady();
        });
    });
    $(".toCategoryList a").on("click", function () {
        clickedOnTextToH1(this);
        var id = $(this).attr("id");
        $.get("/Admin/CategoryList/" + id, function (data) {
            $(".contentSection").html(data);
            adminPageReady();
        });
    });
}

function clickedOnTextToH1(selector) {
    var heading = $(selector).text();
    $("h1").text(heading);
}
