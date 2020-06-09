<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="crm-team-form">

    <?php $form = ActiveForm::begin([ 'enableClientValidation' => true,
    'options'                => [
       'id'      => 'dynamic-form'
        ]]
    ); ?>
<div class="modal-header">
<div class="row">
<div class="form-group col-md-6">

<?php
use yii\helpers\ArrayHelper;
use app\models\CrmTeam;
use app\models\ResCompany;
use app\models\ResUsers;
use app\models\MailAlias;
 
/*Al tener la relacion en el modelo nos es posible en ves de cargar el id el nombre directamente 
al registrar el nuevo empleado guardara el id */
$Scheduler= ResCompany::find()
->all();

$SchedulerList=ArrayHelper::map($Scheduler,'id','name');

$Scheduler1= ResUsers::find()
->all();

$SchedulerList1=ArrayHelper::map($Scheduler1,'id','login');

$Scheduler2= MailAlias::find()
->all();

$SchedulerList2=ArrayHelper::map($Scheduler2,'id','alias_name');
 
?>

</div>
</div>

    <!-- <div class="form-group col-md-6">
          <?= $form->field($model, 'message_main_attachment_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'message_main_attachment_id Cliente']) ?> 
    </div>-->

    <div class="form-group col-md-6">
          <?= $form->field($model, 'name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre de Equipo de Venta']) ?> 
    </div>
       

   <!-- <div class="form-group col-md-6">
         <?= $form->field($model, 'sequence')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'sequence']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'active')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Estatus']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'company_id')->dropDownList($SchedulerList,['prompt'=>'Seleccione una compañia','style'=>'width:400px']); ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'user_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'user_id']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'color')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'color']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'create_uid')->dropDownList($SchedulerList1,['prompt'=>'Seleccione el email del usuario asignado','style'=>'width:400px']);  ?> 
    </div>

    <div class="form-group col-md-6">
          <?php $fecha = date('Y-m-d'); ?>
        <?= $form->field($model, 'create_date' )->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha de Creación', 'type'=>'date', 'min'=> $fecha]) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'write_uid')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'write_uid']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'write_date')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'write_date']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'use_leads')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'use_leads']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'use_opportunities')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Estatus de Oportunidades']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'alias_id')->dropDownList($SchedulerList2,['prompt'=>'Seleccione el alias','style'=>'width:400px']); ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'use_quotations')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'use_quotations']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'invoiced_target')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'invoiced_target']) ?> 
    </div>

   
</div>
    <div class="form-group">
        <?= Html::submitButton('Guardar', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>

</div>
