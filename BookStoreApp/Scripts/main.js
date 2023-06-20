var chat_box =  document.getElementById('chat-box');
var chat_box_button = document. getElementById('chat-box-button');
var hide_button = document.getElementById('hide_button');
var is_show_chatbox = false;

chat_box_button.onclick = function(){

    if(!is_show_chatbox){
        chat_box.style.display = "block"; 
        chat_box.style.transition = "1s"
        is_show_chatbox = true;       
    }
    else{
        chat_box.style.display = "none"; 
        is_show_chatbox = false;      
    }    
}

hide_button.onclick = function (){
    chat_box.style.display = "none"; 
        is_show_chatbox = false;    
}