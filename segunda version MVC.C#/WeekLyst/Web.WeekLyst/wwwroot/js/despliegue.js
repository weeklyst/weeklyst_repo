$(document).on('ready',add);

function add(){
  $("#otro").on('click',despliegue);
}

function despliegue(){

  $(this.#program).append(
    $('<input>').attr('type','text').addClass('form-control')
  )
}