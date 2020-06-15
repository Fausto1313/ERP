<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="product-template-form">

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
use app\models\ProductTemplate;
use app\models\ResCompany;
use app\models\ProductCategory;
 
/*Al tener la relacion en el modelo nos es posible en ves de cargar el id el nombre directamente 
al registrar el nuevo empleado guardara el id */
$Scheduler= ResCompany::find()
->all();

$SchedulerList=ArrayHelper::map($Scheduler,'name','name');

$Scheduler2= ProductCategory::find()
->all();

$SchedulerList2=ArrayHelper::map($Scheduler2,'name','name');

 
?>

</div>


    <div class="form-group col-md-6">
          <?= $form->field($model, 'name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre de Producto']) ?> 
    </div>
       

   <div class="form-group col-md-6">
         <?= $form->field($model, 'description')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Descripción']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'description_sale')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Descripción de venta']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'type')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Consumible/Producto/Servicio']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'categ_name')->dropDownList($SchedulerList2,['prompt'=>'Seleccione una categoria','style'=>'width:400px']); ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'list_price')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Precio']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'company_name')->dropDownList($SchedulerList,['prompt'=>'Seleccione una compañia','style'=>'width:400px']); ?> 
    </div>    


    <div class="form-group col-md-6">
         <?= $form->field($model, 'active')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Activo/Inactivo']) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'image')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Subir archivo', 'type'=>'file', 'class'=>'form-control-file']) ?> 
    </div>-->
   

     <div class="form-group col-md-6">
          <?php $fecha = date('Y-m-d'); ?>
        <?= $form->field($model, 'create_date' )->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha de Creación', 'type'=>'date']) ?> 
    </div>
   
</div>
    <div class="form-group">
        <?= Html::submitButton('Guardar', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>

</div>
