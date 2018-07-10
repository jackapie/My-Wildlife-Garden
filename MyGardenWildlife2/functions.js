function hideSomething(whatToHide)
{
    $('.hidden').removeClass('hidden');
    $(whatToHide).addClass('hidden');
}

function showSomething(whatToShow)
{
    $('.photoSection p').hide();
    $(whatToShow).show();
}

function toggleSomething(whatToToggle)
{
    
    $(whatToToggle).toggle();

}

$(document).ready(function ()
{
    $('.photoSection p, .speciesList div').hide();
});