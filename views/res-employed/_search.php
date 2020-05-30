<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;
?>

<div class="res-employed-search">

    <?php $form = ActiveForm::begin([
        'action' => ['index'],
        'method' => 'get',
    ]); ?>

    <?= $form->field($model, 'Id') ?>

    <?= $form->field($model, 'Id_Comp') ?>

    <?= $form->field($model, 'N_Empleado') ?>

    <?= $form->field($model, 'E_Apellidos') ?>

    <?= $form->field($model, 'E_Nomina') ?>

    <?php // echo $form->field($model, 'F_Creacion') ?>

    <?php // echo $form->field($model, 'ID_Partner') ?>

    <div class="form-group">
        <?= Html::submitButton('Search', ['class' => 'btn btn-primary']) ?>
        <?= Html::resetButton('Reset', ['class' => 'btn btn-outline-secondary']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
