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

    $(".toSectionList").on("click", function () {
        clickedOnTextToH1(this);

        $.get("/Admin/SectionList/", function (data) {
            $(".contentSection").html(data);
        });
    });
});

function clickedOnTextToH1(selector) {
    var heading = $(selector).text();
    $("h1").text(heading);
}
