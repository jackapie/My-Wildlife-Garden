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
        var heading = $(this).text();
        $("h1").text(heading);

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
        var heading = $(this).text();
        $("h1").text(heading);

        $.get("/Admin/SectionList/", function (data) {
            $(".contentSection").html(data);
        });
    });
});