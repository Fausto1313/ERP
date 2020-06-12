<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;
?>

<div class="res-company-form">

    <?php $form = ActiveForm::begin([ 'enableClientValidation' => true,
    'options'                => [
       'id'      => 'dynamic-form'
        ]]
    ); ?>

<div class="modal-header">
<div class="row">
<div class="form-group col-md-6">



</div>

    <div class="form-group col-md-6">
          <?= $form->field($model, 'name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre de la compañia']) ?> 
    </div>
       

   <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'partner_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'partner_id']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'currency_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'currency_id']) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'sequence')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'sequence']) ?> 
    </div>-->

    <!--<div class="form-group col-md-6">
          <?php $fecha = date('Y-m-d'); ?>
        <?= $form->field($model, 'parent_id' )->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'parent_id', 'type'=>'date', 'min'=> $fecha]) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'report_header')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'report_header']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'report_footer')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'report_footer']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'logo_web')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'logo_web']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'account_no')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'account_no']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'logo_web')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Logo para sitio']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'email')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'phone')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Telefono']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'social_linkedin')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Sitio Web']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'social_twitter')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Twitter']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'social_facebook')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Facebook']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'social_youtube')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Canal de Youtube']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'social_instagram')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Intagram']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'company_registry')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Compañia registrada']) ?> 
    </div>


    <div class="form-group col-md-6">
         <?= $form->field($model, 'fiscalyear_last_day')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'fiscalyear_last_day']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'fiscalyear_last_month')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'fiscalyear_last_month']) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'period_lock_date')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'period_lock_date']) ?> 
    </div>


    <div class="form-group col-md-6">
         <?= $form->field($model, 'vat_check_vies')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'vat_check_vies']) ?> 
    </div>-->

     <div class="form-group col-md-6">
         <?= $form->field($model, 'manufacturing_lead')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'manufacturing_lead']) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'portal_confirmation_sign')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'portal_confirmation_sign']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'security_lead')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'security_lead']) ?> 
    </div>

      <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'website_sale_onboarding_payment_acquirer_state')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'website_sale_onboarding_payment_acquirer_state']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'po_lead')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'po_lead']) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'po_lock')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'po_lock']) ?> 
    </div>-->

    <div class="form-group col-md-6">
          <?php $fecha = date('Y-m-d'); ?>
        <?= $form->field($model, 'create_date' )->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha de Creación', 'type'=>'date', 'min'=> $fecha]) ?> 
    </div>

</div>   

    <div class="form-group">
        <?= Html::submitButton('Guardar', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>

</div>
