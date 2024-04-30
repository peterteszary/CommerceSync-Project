<?php
// woosync-scripts.php

function woosync_enqueue_scripts() {
    //Saját stíluslap hozzáadása
    wp_enqueue_style('woosync-css', plugin_dir_url(__FILE__) . '../css/woosync.css', array(), '1.0');

    // BootStrap CSS hozzáadása
    wp_enqueue_style('bootstrap-css', plugin_dir_url(__FILE__) . '../css/bootstrap.min.css', array(), '5.3.0');

    // Plugin JavaScript hozzáadása
    wp_enqueue_script('woosync-script', plugin_dir_url(__FILE__) . '../js/woosync-script.js', array('jquery'), '1.0', true);

    // BootStrap JavaScript hozzáadása
    wp_enqueue_script('bootstrap-js', plugin_dir_url(__FILE__) . '../js/bootstrap.min.js', array('jquery'), '5.3.0', true);

    // Lokalizáció az AJAX hívásokhoz
    wp_localize_script('woosync-script', 'woosync_ajax_obj', array(
        'ajax_url' => admin_url('admin-ajax.php'),
        'security' => wp_create_nonce('woosync_ajax_nonce')
    ));
}
?>
