$(document).ready(function () {
    $("#tabla-subtareas").hide();
    $("#empleados").css("color", "#FFF");
  $("#empleados").click(function () {
      $("#empleados").css("color", "#FFF");
      $("#subtarea").css("color", "#808080");
      $("#tabla-empleados").show();
      $("#tabla-subtareas").hide();
  });
  $("#subtarea").click(function(){
      $("#subtarea").css("color", "#FFF");
      $("#empleados").css("color", "#808080");
      $("#tabla-empleados").hide();
      $("#tabla-subtareas").show();
  });
});