$("#MainContent_ddlUf").on('change', function () {
    if ($("#MainContent_ddlUf").val() == 1) {
        $("#MainContent_ddlCidades").val(1);
    }
    if ($("#MainContent_ddlUf").val() == 2) {
        $("#MainContent_ddlCidades").val(2);
    }
    if ($("#MainContent_ddlUf").val() == 3) {
        $("#MainContent_ddlCidades").val(3);
    }
});