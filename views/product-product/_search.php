<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="product-product-search">

    <?php $form = ActiveForm::begin([
        'action' => ['index'],
        'method' => 'get',
    ]); ?>

    <?= $form->field($model, 'id') ?>

    <?= $form->field($model, 'message_main_attachment_id') ?>

    <?= $form->field($model, 'default_code') ?>

    <?= $form->field($model, 'active') ?>

    <?= $form->field($model, 'product_tmpl_id') ?>

    <?php // echo $form->field($model, 'barcode') ?>

    <?php // echo $form->field($model, 'combination_indices') ?>

    <?php // echo $form->field($model, 'volume') ?>

    <?php // echo $form->field($model, 'weight') ?>

    <?php // echo $form->field($model, 'can_image_variant_1024_be_zoomed') ?>

    <?php // echo $form->field($model, 'create_uid') ?>

    <?php // echo $form->field($model, 'create_date') ?>

    <?php // echo $form->field($model, 'write_uid') ?>

    <?php // echo $form->field($model, 'write_date') ?>

    <?php // echo $form->field($model, 'trial375') ?>

    <div class="form-group">
        <?= Html::submitButton('Search', ['class' => 'btn btn-primary']) ?>
        <?= Html::resetButton('Reset', ['class' => 'btn btn-outline-secondary']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
