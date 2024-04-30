<?php require_once plugin_dir_path( __FILE__ ) . '/../navigation/woosync-menu.php'; ?>

<div class="wrap container">
  <h1 class="mb-4">WooSync Authentication</h1>
  <p class="mb-4 text--info-large">You can generate and copy or reset your API key here. It will be stored in the database</p>
  <?php 
  // Az API kulcs lekérése az adatbázistáblából
  global $wpdb;
  $table_name = $wpdb->prefix . 'woosync_api_keys';
  $existing_key = $wpdb->get_var("SELECT api_key FROM $table_name");
  ?>
  <div class="card">
    <div class="card-body">
      <?php if ( $existing_key ) : ?>
        <p class="text--info"><strong>Your API Key: </strong><?php echo esc_html( $existing_key ); ?></p>
        <button class="btn--woosync copy-api-key-btn" data-api-key="<?php echo esc_attr( $existing_key ); ?>">Copy API Key</button>
        <form method="post" action="" class="d-inline">
          <input type="hidden" name="woosync_reset_key" value="1">
          <?php wp_nonce_field( 'woosync_reset_key_nonce', 'woosync_reset_key_nonce' ); ?>
          <button type="submit" class="btn--woosync-danger reset-api-key-btn">Reset API Key</button>
        </form>
      <?php else: ?>
        <button id="generate-api-key-btn" class="btn--woosync">Generate API Key</button>
      <?php endif; ?>
    </div>
  </div>
</div>
