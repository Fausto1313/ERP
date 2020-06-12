<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="res-partner-form">

    <?php $form = ActiveForm::begin([ 'enableClientValidation' => true,
    'options' => [
       'id' => 'dynamic-form'
        ]]
    ); ?>

<div class="modal-header">
<div class="row">
<div class="form-group col-md-6">
    <?php
    use yii\helpers\ArrayHelper;
    use app\models\ResPartner;
    use app\models\ResCompany;
    use app\models\ResCountry;
     
    /*Al tener la relacion en el modelo nos es posible en ves de cargar el id el nombre directamente 
    al registrar el nuevo empleado guardara el id */
    $Scheduler= ResCompany::find()
    ->all();
    $SchedulerList=ArrayHelper::map($Scheduler,'name','name');

    $Scheduler1= ResCountry::find()
    ->all();
    $SchedulerList1=ArrayHelper::map($Scheduler1,'name','name');
    
     

    echo $form->field($model, 'company_name')->dropDownList($SchedulerList,['prompt'=>'Seleccione una compañia', 'style'=>'width:400px']);
     
    ?>

</div>
     <div class="form-group col-md-6">
          <?= $form->field($model, 'name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre del Cliente']) ?> 
    </div>       

   <div class="form-group col-md-6">

        <?php $fecha = date('Y-m-d'); ?>
        <?= $form->field($model, 'create_date' )->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha de Creación', 'type'=>'date', 'min'=> $fecha]) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'display_name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre a mostrar']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'date')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'title')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Titulo']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'parent_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Id Cliente']) ?>  <!-- Es el cliente al que partenece (su padre)
    </div>-->

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'ref')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'ref']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'lang')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'lang']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'tz')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'tz']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'user_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Id Usuario']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'vat')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'RFC']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'website')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Sitio web']) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'comment')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'comment']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'active')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Activo/Inactivo']) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'employee')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Empleado']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'function')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Funcion']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'type')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Tipo de cliente']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'street')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Calle']) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'street2')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Calle 2']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'zip')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Codigo postal']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'city')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Ciudad']) ?> 
    </div>
     
    <div class="form-group col-md-6">
         <?=  $form->field($model, 'country_name')->dropDownList($SchedulerList1,['prompt'=>'Seleccione un pais','style'=>'width:400px']); ?> 
    </div>

     <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'partner_latitude')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'partner_latitude']) ?> 
    </div>

     <div class="form-group col-md-6">
         <?= $form->field($model, 'partner_longitude')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'partner_longitude']) ?> 
    </div>-->

     <div class="form-group col-md-6">
         <?= $form->field($model, 'email')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email']) ?> 
    </div>

     <div class="form-group col-md-6">
         <?= $form->field($model, 'phone')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Telefono']) ?> 
    </div>

     <div class="form-group col-md-6">
         <?= $form->field($model, 'mobile')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Celular']) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'is_company')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Es compañia']) ?>  Queda pendiente ****
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'industry_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'industry_id']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'color')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'color']) ?> 
    </div>-->

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'partner_share')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'partner_share']) ?> 
    </div>-->

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'commercial_partner_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'commercial_partner_id']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'commercial_company_name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'commercial_company_name']) ?> 
    </div>-->

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'company_name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre de Compañia']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'create_uid')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Id Usuario']) ?> 
    </div>-->

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'write_uid')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'write_uid']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'write_date')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'write_date']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'message_main_attachment_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'message_main_attachment_id']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'email_normalized')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'email_normalized']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'message_bounce')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'message_bounce']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'signup_token')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'signup_token']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'signup_type')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'signup_type']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'signup_expiration')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'signup_expiration']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'partner_gid')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'partner_gid']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'additional_info')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'additional_info']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'phone_sanitized')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'phone_sanitized']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'website_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'website_id']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'is_published')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'is_published']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'calendar_last_notif_ack')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'calendar_last_notif_ack']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'team_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'team_id']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'picking_warn')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'picking_warn']) ?> 
    </div>

     <div class="form-group col-md-6">
         <?= $form->field($model, 'picking_warn_msg')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'picking_warn_msg']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'debit_limit')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'debit_limit']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'last_time_entries_checked')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'last_time_entries_checked']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'invoice_warn')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'invoice_warn']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'supplier_rank')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'supplier_rank']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'customer_rank')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'customer_rank']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'sale_warn')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'sale_warn']) ?> 
    </div>

     <div class="form-group col-md-6">
         <?= $form->field($model, 'sale_warn_msg')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'sale_warn_msg']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'purchase_warn')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'purchase_warn']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'purchase_warn_msg')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'purchase_warn_msg']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'website_meta_title')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'website_meta_title']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'website_meta_description')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'website_meta_description']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'website_meta_keywords')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'website_meta_keywords']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'website_meta_og_img')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'website_meta_og_img']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'website_description')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'website_description']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'website_short_description')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'website_short_description']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'customer')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'customer']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'trial496')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'trial496']) ?> 
    </div>-->
</div>

    <div class="form-group">
        <?= Html::submitButton('Guardar', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>

</div>