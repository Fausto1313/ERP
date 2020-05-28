<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;
?>

<div class="res-country-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'name')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'code')->textInput(['maxlength' => true]) ?>

    <?= $form->field($model, 'address_format')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'address_view_id')->textInput() ?>

    <?= $form->field($model, 'currency_id')->textInput() ?>

    <?= $form->field($model, 'phone_code')->textInput() ?>

    <?= $form->field($model, 'name_position')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'vat_label')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'create_uid')->textInput() ?>

    <?= $form->field($model, 'create_date')->textInput() ?>

    <?= $form->field($model, 'write_uid')->textInput() ?>

    <?= $form->field($model, 'write_date')->textInput() ?>

    <?= $form->field($model, 'trial434')->textInput(['maxlength' => true]) ?>

    <div class="form-group">
        <?= Html::submitButton('Save', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
