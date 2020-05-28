<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="product-product-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'message_main_attachment_id')->textInput() ?>

    <?= $form->field($model, 'default_code')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'active')->textInput() ?>

    <?= $form->field($model, 'product_tmpl_id')->textInput() ?>

    <?= $form->field($model, 'barcode')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'combination_indices')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'volume')->textInput() ?>

    <?= $form->field($model, 'weight')->textInput() ?>

    <?= $form->field($model, 'can_image_variant_1024_be_zoomed')->textInput() ?>

    <?= $form->field($model, 'create_uid')->textInput() ?>

    <?= $form->field($model, 'create_date')->textInput() ?>

    <?= $form->field($model, 'write_uid')->textInput() ?>

    <?= $form->field($model, 'write_date')->textInput() ?>

    <?= $form->field($model, 'trial375')->textInput(['maxlength' => true]) ?>

    <div class="form-group">
        <?= Html::submitButton('Save', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
