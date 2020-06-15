<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;
?>

<div class="product-category-form">

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
use app\models\ProductCategory;
 
/*Al tener la relacion en el modelo nos es posible en ves de cargar el id el nombre directamente 
al registrar el nuevo empleado guardara el id */
 
?>

</div>


    <div class="form-group col-md-6">
          <?= $form->field($model, 'name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre de la categoria']) ?> 
    </div>
       

   <div class="form-group col-md-6">
         <?= $form->field($model, 'complete_name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre completo']) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'parent_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'parent_id']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'create_uid')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'create_uid']) ?> 
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
